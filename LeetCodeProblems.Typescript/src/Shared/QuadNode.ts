export class QuadNode {
    val: boolean
    isLeaf: boolean
    topLeft: QuadNode | null
    topRight: QuadNode | null
    bottomLeft: QuadNode | null
    bottomRight: QuadNode | null
    constructor(val?: boolean, isLeaf?: boolean, topLeft?: QuadNode, topRight?: QuadNode, bottomLeft?: QuadNode, bottomRight?: QuadNode) {
        this.val = (val===undefined ? false : val)
        this.isLeaf = (isLeaf===undefined ? false : isLeaf)
        this.topLeft = (topLeft===undefined ? null : topLeft)
        this.topRight = (topRight===undefined ? null : topRight)
        this.bottomLeft = (bottomLeft===undefined ? null : bottomLeft)
        this.bottomRight = (bottomRight===undefined ? null : bottomRight)
  }
}