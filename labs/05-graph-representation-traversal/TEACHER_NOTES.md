# Teacher Notes - Lab 5

## Intended starter state

- 13 supplied tests total.
- 4 pass.
- 9 fail.

The passing tests establish:

1. the edge-list baseline returns outgoing neighbors correctly;
2. isolated nodes can exist in the baseline;
3. `AdjacencyGraph` creates a bucket for every supplied node;
4. querying an unknown adjacency node returns an empty list.

The failing tests correspond to:

- grouping edges into adjacency lists;
- BFS;
- DFS;
- BFS reachability.

## Core teaching target

Keep three layers explicit:

```text
graph problem
→ representation
→ traversal policy
```

A graph is the domain structure.

Adjacency is one representation organized around repeated neighbor queries.

BFS/DFS are traversal algorithms over that representation.

Students should be able to explain why these are separate choices.

## Example graph

```text
Entrance
├─> Hall
│   ├─> Armory ─> BossRoom
│   └─> Courtyard ─> BossRoom
│          └────────> Hall
└─> StoreRoom ─> Courtyard

SecretRoom   disconnected
```

Reference outputs:

```text
Neighbors(Hall):
Armory, Courtyard

BFS from Entrance:
Entrance, Hall, StoreRoom, Armory, Courtyard, BossRoom

DFS from Entrance:
Entrance, Hall, Armory, BossRoom, Courtyard, StoreRoom

Reachable Entrance -> BossRoom:
true

Reachable Entrance -> SecretRoom:
false
```

## Important distinctions

### Tree vs graph

A tree has a constrained hierarchical shape.

A general graph may contain:

- cycles;
- multiple incoming paths;
- disconnected components;
- arbitrary connectivity.

Recursive tree traversal did not need a visited set because the supplied Lab 4A hierarchy had no back edges/cycles.

Graph traversal usually needs explicit visited tracking.

### BFS vs DFS

They share the same broad pattern:

```text
frontier
visited
neighbors
```

The frontier policy changes:

```text
BFS → Queue
DFS → Stack
```

### BFS vs Dijkstra

Do not blur these.

BFS:
- unweighted / equal edge cost reasoning;
- frontier order is discovery order.

Dijkstra:
- weighted edges;
- frontier order is smallest known total cost;
- priority queue.

The course should make Dijkstra feel like a deliberate modification of the frontier rule, not a completely unrelated algorithm.

## Representation complexity

Edge-list baseline:

```text
GetNeighbors(v) O(E)
```

Adjacency:

```text
prepare O(V + E)
lookup list expected O(1)
process neighbors O(degree(v))
```

Full BFS/DFS with adjacency:

```text
O(V + E)
```

Space:

```text
adjacency O(V + E)
visited O(V)
frontier O(V) worst case
```

## Common misconceptions

- "A graph is just a tree."  
  A tree is a special kind of graph with stronger constraints.

- "BFS means recursive and DFS means iterative."  
  Traversal order and implementation mechanism are separate. Both can be implemented in several ways.

- "Visited means processed."  
  In this lab, mark a node visited when it is discovered/enqueued/pushed so it is not added repeatedly.

- "If there is an edge A -> B, B -> A is implied."  
  Not in a directed graph.

- "BFS gives the cheapest path."  
  Only when all edges have equal cost / when shortest means fewest edges. Frontier Dispatch uses travel costs.

- "Adjacency is always better."  
  It pays preparation and memory to optimize repeated neighbor access.

## Suggested live-code boundary

Recommended:

1. Trace the edge-list `GetNeighbors` baseline.
2. Build the adjacency table on the board.
3. Optionally live-code the single missing edge-grouping line.
4. Trace BFS manually with a Queue and visited set.
5. Do **not** live-code all traversal methods.

Let students implement BFS and DFS from the traced state transitions.

If the class is struggling, live-code BFS only and leave DFS + reachability as transfer tasks.

## Useful board table for BFS

```text
Step | Queue                  | Visited                         | Process
0    | Entrance               | Entrance                        |
1    | Hall, StoreRoom        | Entrance, Hall, StoreRoom       | Entrance
2    | StoreRoom, Armory,
       Courtyard              | + Armory, Courtyard             | Hall
...
```

Emphasize that the queue is not "the graph". It is temporary algorithm state.

## Assignment bridge

By the end of Lab 5 students should have the conceptual prerequisites for:

- graph representation;
- visited/frontier reasoning;
- understanding why weighted route search needs a different frontier policy.

They still should not be expected to invent Dijkstra independently before it is taught.

## Next teaching step

The next weighted-path session should transform:

```text
BFS:
Queue frontier
```

into:

```text
Dijkstra:
PriorityQueue frontier
```

while adding:

```text
best known distance
relaxation
predecessor / route reconstruction
```

That is the key conceptual bridge.
