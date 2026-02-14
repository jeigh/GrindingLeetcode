#pragma once

#include "TreeNode.h"
#include <vector>

using namespace std;

class AbstractConstructBinaryTreeFromInorderAndPostorderTraversal_106 {
	virtual TreeNode* buildTree(vector<int>& inorder, vector<int>& postorder) = 0;
};