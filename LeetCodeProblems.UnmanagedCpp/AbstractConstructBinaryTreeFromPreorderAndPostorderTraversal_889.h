#pragma once

#include "TreeNode.h"
#include <vector>

using namespace std;

class AbstractConstructBinaryTreeFromPreorderAndPostorderTraversal_889 {
	virtual TreeNode* constructFromPrePost(vector<int>& preorder, vector<int>& postorder) = 0;
};