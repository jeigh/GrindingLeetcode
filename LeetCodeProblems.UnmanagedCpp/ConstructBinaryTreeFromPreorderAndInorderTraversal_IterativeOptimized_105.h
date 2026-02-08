#pragma once

#include "AbstractConstructBinaryTreeFromPreorderAndInorder_105.h"
#include <stack>
#include <unordered_map>


class ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeOptimized_105 : public AbstractConstructBinaryTreeFromPreorderAndInorder_105 {
	using index = long long unsigned;

	class StackFrame
	{
	public:
		index inorderLeft = 0;
		index inorderRight = 0;
		bool isRight = false;
		TreeNode * parent = nullptr;

		StackFrame(TreeNode* parent, const index inorderLeft, const index inorderRight, const bool isRight)
			: parent(parent), inorderLeft(inorderLeft), inorderRight(inorderRight), isRight(isRight) { }
	};
private:
	inline std::unordered_map<int, index> PopulateInorderIndices(const vector<int>& vector)
	{
		std::unordered_map<int, index> returnable;
		for (index i = 0; i < vector.size(); i++) returnable[vector[i]] = i;
		return returnable;
	}

public:
	inline TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) override {
		if (preorder.empty()) return nullptr;

		auto stack = std::stack<StackFrame>();
		std::unordered_map<int, index> inorderIndices = PopulateInorderIndices(inorder);

		index preorderIndex = 0;

		stack.emplace(nullptr, 0, inorder.size() - 1, true);
		TreeNode * root = nullptr;

		while (!stack.empty())
		{
			const StackFrame p = stack.top();
			stack.pop();

			if (p.inorderLeft > p.inorderRight) continue;

			int currentValue = preorder[preorderIndex++];
			auto node = new TreeNode(currentValue);

			if (p.parent == nullptr) root = node;
			else if (p.isRight) p.parent->right = node;
			else p.parent->left = node;

			const index inorderIndex = inorderIndices[currentValue];

			if (inorderIndex < p.inorderRight) 
				stack.emplace(node, inorderIndex + 1, p.inorderRight, true);
			
			if (p.inorderLeft < inorderIndex) 
				stack.emplace(node, p.inorderLeft, inorderIndex - 1, false);
		}
		return root;
	}

};
