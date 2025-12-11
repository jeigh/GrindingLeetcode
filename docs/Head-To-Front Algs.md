# Head-to-Front Linked list Algorithms

## First Iteration
### Initial State
```mermaid
graph LR
    dummy["dummy(0)"] --> n1["1 <br> (prevNode)"]
    n1 --> n2["2 <br> (anchor)"]
    n2 --> n3["3"]
    n3 --> n4["4"]
    n4 --> n5["5"]
    n5 --> null1["null"]
    
    style dummy fill:#e1f5ff
    style n1 fill:#fff3cd
    style n2 fill:#d4edda
    
    
```

### Step 1: set nextNode
```visualbasic
Dim nextNode = anchor.next
```
```mermaid
graph LR
    dummy["dummy(0)"] --> n1["1 <br> (prevNode)"]
    n1 --> n2["2 <br> (anchor)"]
    n2 --> n3["3 <br> (nextNode)"]
    n3 --> n4["4"]
    n4 --> n5["5"]
    n5 --> null1["null"]
    
    style dummy fill:#e1f5ff
    style n1 fill:#fff3cd
    style n2 fill:#d4edda
    style n3 fill:#f8d7da
```

### Step 2: target anchor.next to anchor.next.next
```visualBasic
anchor.next = anchor.next.next
```
```mermaid
graph LR
    dummy["dummy(0)"] --> n1["1 <br> (prevNode)"]
    n1 --> n2["2 <br> (anchor)"]
    n2 --> n4["4"]
    n4 --> n5["5"]
    n5 --> null1["null"]
    
    n3["3 <br> (nextNode)"] --> n4["4"]
    
    style dummy fill:#e1f5ff
    style n1 fill:#fff3cd
    style n2 fill:#d4edda
    style n3 fill:#f8d7da
    style n4 fill:#e2e3e5
```
### Step 3 - move nextNode to point to prevNode.next

```vb
nextNode.next = prevNode.next
```
```mermaid
graph LR
    dummy["dummy(0)"] --> n1["1 <br> (prevNode)"]
    n1 --> n2["2 <br> (anchor)"]
    n2 --> n4["4"]
    n4 --> n5["5"]
    n5 --> null1["null"]
    
    n3["3 <br> (nextNode)"] --> n2
    
    style dummy fill:#e1f5ff
    style n1 fill:#fff3cd
    style n2 fill:#d4edda
    style n3 fill:#f8d7da
    style n4 fill:#e2e3e5

```

### Step 4, reconnect nextNode to the graph
```vb
prevNode.next = nextNode
```
```mermaid
graph LR
    dummy["dummy(0)"] --> n1["1 <br> (prevNode)"]
    n1 --> n3
    n2["2 <br> (anchor)"] --> n4["4"]
    n4 --> n5["5"]
    n5 --> null1["null"]
    
    n3["3 <br> (nextNode)"] --> n2
    
    style dummy fill:#e1f5ff
    style n1 fill:#fff3cd
    style n2 fill:#d4edda
    style n3 fill:#f8d7da
    style n4 fill:#e2e3e5

```


## Subsequent Iterations...
