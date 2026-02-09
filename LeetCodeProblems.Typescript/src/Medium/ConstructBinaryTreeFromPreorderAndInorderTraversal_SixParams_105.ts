import {IConstructBinaryTreeFromPreorderAndInorderTraversal_105} from "../Interfaces/Medium/IConstructBinaryTreeFromPreorderAndInorderTraversal_105";
import {TreeNode} from "../Shared";

type index = number;

export class ConstructBinaryTreeFromPreorderAndInorderTraversal_SixParams_105 implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105 {
    buildTree(preorder: number[], inorder: number[]): TreeNode | null 
    {
        if (preorder.length == 0) return null;

        return this.buildSubTree(preorder, inorder, 0, preorder.length, 0, inorder.length);
    }

    buildSubTree(preorder: number[], inorder: number[], preStart: index, preEnd: index, inStart:index, inEnd:index): TreeNode | null 
    {
        if (preStart >= preEnd || inStart >= inEnd) return null;
        if (inorder.length < inEnd) return null;
        if (preorder.length < preEnd) return null;

        let currentValue = preorder[preStart]!;
        let inIndex = this.getInorderIndex(inorder, currentValue, inStart, inEnd)!;
        let leftLength = inIndex - inStart;
        let preRightStart = preStart + 1 + leftLength;

        let leftPreStart : number = preStart + 1;
        let leftPreEnd : number = preRightStart;
        let leftInStart: number = inStart;
        let leftInEnd: number = inIndex;

        let rightPreStart: number = preRightStart;
        let rightPreEnd: number = preEnd;
        let rightInStart: number = inIndex + 1;
        let rightInEnd: number = inEnd;

        let left = this.buildSubTree(preorder, inorder, leftPreStart, leftPreEnd, leftInStart, leftInEnd);
        let right = this.buildSubTree(preorder, inorder, rightPreStart, rightPreEnd, rightInStart, rightInEnd);

        return new TreeNode(currentValue, left, right);
    }

    getInorderIndex(inorder: number[], currentValue: number, inStart: index, inEnd: index): number | null
    {
        for (let i:number = inStart; i <= inEnd; i++) 
        {
            if (inorder[i] == currentValue) return i;
        }
        return null;
    }
}

