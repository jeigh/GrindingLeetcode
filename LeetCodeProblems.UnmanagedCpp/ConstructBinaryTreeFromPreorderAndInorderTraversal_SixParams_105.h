#pragma once

#include "AbstractConstructBinaryTreeFromPreorderAndInorder_105.h"
#include <stdexcept>

class ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105 : AbstractConstructBinaryTreeFromPreorderAndInorder_105 {
private:
	using index = long long unsigned ;

public:
	inline TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) override
	{
		return CreateSubtree(preorder, inorder, 0, preorder.size(), 0, inorder.size());
	}

private:
	static inline index GetInorderIndex(const int current_value, const vector<int>& vector, const index inStart, const index inEnd)
	{
		for (index i = inStart; i < inEnd; i++)
		{
			if (vector[i] == current_value) return i;
		}
		throw std::logic_error("value not contained in vector");
	}

	static inline index GetPreorderRightTreeStartIndex(const index pre_start, const index in_start, const index current_inorder_index)
	{
		index leftSubtreeSize = current_inorder_index - in_start;
		return 1 + leftSubtreeSize + pre_start;
	}

	static inline TreeNode* CreateSubtree(vector<int>& preorder, vector<int>& inorder, const index preStart, const index preEnd, const index inStart, const index inEnd)
	{
		if (preStart >= preEnd || inStart >= inEnd) return nullptr;
		
		const int currentValue = preorder[preStart];
		const index currentInorderIndex = GetInorderIndex(currentValue, inorder, inStart, inEnd);
		const index preorderRightTreeStartIndex = GetPreorderRightTreeStartIndex(preStart, inStart, currentInorderIndex);

		TreeNode* left = CreateSubtree(preorder, inorder, preStart + 1, preorderRightTreeStartIndex, inStart, currentInorderIndex);
		TreeNode* right = CreateSubtree(preorder, inorder, preorderRightTreeStartIndex, preEnd, currentInorderIndex + 1, inEnd);

		return new TreeNode(currentValue, left, right);
	}
};
