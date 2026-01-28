#pragma once

#include <vector>
#include "QuadNode.h"

class ConstructQuadTree_427 {
public:
    virtual ~ConstructQuadTree_427() = default;
    virtual QuadNode* construct(std::vector<std::vector<int>>& grid) = 0;
};
