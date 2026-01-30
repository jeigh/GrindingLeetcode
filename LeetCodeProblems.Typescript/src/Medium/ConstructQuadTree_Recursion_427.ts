import { IConstructQuadTree_Recursion_427 } from "../Interfaces/Medium/IConstructQuadTree_Recursion_427"; 
import { QuadNode } from "../Shared/QuadNode";

export class ConstructQuadtree_Recursion_427 implements IConstructQuadTree_Recursion_427 {
    construct(grid: number[][]): QuadNode | null 
    {
        if (grid.length == 0) return null;
        return this.recurse(grid, grid.length, 0, 0);
    }

    recurse(grid: number[][], regionSize: number, rowStart: number, colStart: number): QuadNode  {
        if (this.isUniform(grid, regionSize, rowStart, colStart)) 
            return new QuadNode(grid[rowStart]![colStart] == 1, true);

        let half = regionSize / 2 | 0

        let topLeft = this.recurse(grid, half, rowStart, colStart);
        let topRight = this.recurse(grid, half, rowStart, colStart + half);
        let bottomLeft = this.recurse(grid, half, rowStart+half, colStart);
        let bottomRight = this.recurse(grid, half, rowStart+half, colStart + half);

        return new QuadNode(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }

    isUniform(grid: number[][], regionSize: number, rowStart: number, colStart: number): boolean {
        let firstVal = grid[rowStart]![colStart];
        
        for (let i = 0; i < regionSize; i++) {
            for (let j = 0; j < regionSize; j++) {
                if (firstVal != grid[rowStart+i]![colStart+j]) return false;
            }
        }
    
         return true;       
    }
}