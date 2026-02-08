#pragma once

#include <vector>
#include "QuadNode.h"

class AbstractConstructQuadTree_427 {
public:
    virtual ~AbstractConstructQuadTree_427() = default;
    virtual QuadNode* construct(std::vector<std::vector<int>>& grid) = 0;
};
