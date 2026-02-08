#pragma once

#include "TreeNode.h"
#include <vector>

using namespace std;

class AbstractConstructBinaryTreeFromPreorderAndInorder_105 {
	virtual TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) = 0;
};