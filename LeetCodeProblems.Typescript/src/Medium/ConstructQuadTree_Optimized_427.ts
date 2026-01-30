import { IConstructQuadTree_Recursion_427 } from "../Interfaces/Medium/IConstructQuadTree_Recursion_427"; 
import { QuadNode } from "../Shared/QuadNode";

export class ConstructQuadTree_Optimized_427 implements IConstructQuadTree_Recursion_427 {
    construct(grid: number[][]): QuadNode | null 
    {
        if (grid.length == 0) return null;
        return this.recurse(grid, grid.length, 0, 0);
    }

    recurse(grid: number[][], regionSize: number, rowStart: number, colStart: number): QuadNode  {
        if (regionSize == 1) return new QuadNode(grid[rowStart]![colStart] == 1, true);

        let half = regionSize / 2 | 0;

        let topLeft = this.recurse(grid, half, rowStart, colStart);
        let topRight = this.recurse(grid, half, rowStart, colStart + half);
        let bottomLeft = this.recurse(grid, half, rowStart + half, colStart);
        let bottomRight = this.recurse(grid, half, rowStart + half, colStart + half);


        if (topLeft.isLeaf && topRight.isLeaf && 
            bottomLeft.isLeaf && bottomRight.isLeaf &&
            topLeft.val == topRight.val && 
            topLeft.val == bottomLeft.val && 
            bottomRight.val == bottomLeft.val) {
            return topLeft;
        }

        return new QuadNode(false, false, topLeft, topRight, bottomLeft, bottomRight);

    }

}
