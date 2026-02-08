#pragma once

#include "AbstractConstructQuadTree_427.h"
#include <stack>
#include <algorithm>


class ConstructQuadTree_Recursive_Optimized_427 : public AbstractConstructQuadTree_427 {
public:
    inline QuadNode* construct(std::vector<std::vector<int>>& grid) override {
        return recurse(grid, static_cast<int>(grid.size()), 0, 0);
    }


private:
    QuadNode* recurse(std::vector<std::vector<int>>& grid, int regionSize, int rowStart, int colStart) {
        if (regionSize == 1) {
            return (grid[rowStart][colStart] == 1) ? new QuadNode(true, true) : new QuadNode(false, true);
        }

        int half = regionSize / 2;

        QuadNode* topLeft = recurse(grid, half, rowStart, colStart);
        QuadNode* topRight = recurse(grid, half, rowStart, colStart + half);
        QuadNode* bottomLeft = recurse(grid, half, rowStart + half, colStart);
        QuadNode* bottomRight = recurse(grid, half, rowStart + half, colStart + half);

        if (topLeft->isLeaf && topRight->isLeaf && 
            bottomLeft->isLeaf && bottomRight->isLeaf &&
            topLeft->val == topRight->val && 
            topLeft->val == bottomLeft->val && 
            bottomLeft->val == bottomRight->val) 
            return topLeft->val ? new QuadNode(true, true) : new QuadNode(false, true);
        

        return new QuadNode(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }

};

