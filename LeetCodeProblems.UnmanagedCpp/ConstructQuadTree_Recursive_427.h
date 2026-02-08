#pragma once
#include "QuadNode.h"
#include <vector>
#include "AbstractConstructQuadTree_427.h"


class ConstructQuadTree_Recursive_427 : public AbstractConstructQuadTree_427 {
public:
    inline QuadNode* construct(std::vector<std::vector<int>>& grid) { 
        return recurse(grid, grid.size(), 0, 0);
    }

private:
    inline QuadNode* recurse(std::vector<std::vector<int>>& grid, int regionSize, int rowStart, int colStart) 
    {
        if (isUniform(grid, regionSize, rowStart, colStart))
            return new QuadNode(grid[rowStart][colStart] == 1, true);

        int half = regionSize / 2;

        auto topLeft = recurse(grid, half, rowStart, colStart);
        auto topRight = recurse(grid, half, rowStart, colStart + half);
        auto bottomLeft = recurse(grid, half, rowStart + half, colStart);
        auto bottomRight = recurse(grid, half, rowStart + half, colStart + half);

        return new QuadNode(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }

    inline bool isUniform(std::vector<std::vector<int>>& grid, int regionSize, int rowStart, int colStart) 
    {
        auto challengeValue = grid[rowStart][colStart];

        for (int i = 0; i < regionSize; i++) {
            for (int j = 0; j < regionSize; j++) {
                if (challengeValue != grid[rowStart + i][colStart + j])
                    return false;
            }
        }
        return true;
    }

};