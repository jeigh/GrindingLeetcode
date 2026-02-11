import {IConstructBinaryTreeFromPreorderAndInorderTraversal_105} from "../Interfaces/Medium/IConstructBinaryTreeFromPreorderAndInorderTraversal_105";
import {TreeNode} from "../Shared";

type index = number;

interface byRefIndex {
    index: index
}

export class ConstructBinaryTreeFromPreorderAndInorderTraversal_FiveParams_105 implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105 
{
    buildTree(preorder: number[], inorder: number[]): TreeNode | null 
    {
        if (preorder.length == 0) return null;

        let preIndex: byRefIndex = {index: 0};
        let inIndex: byRefIndex = {index: 0}

        let limitValue: number | null = null ;
        
        return this.BuildSubTree(preorder, inorder, limitValue, preIndex, inIndex);
    }

    BuildSubTree(preorder: number[], inorder: number[], limitValue: number | null, preIndex: byRefIndex, inIndex: byRefIndex): TreeNode | null 
    {
        if (preIndex.index >= preorder.length || inIndex.index >= inorder.length) return null;
        
        if (this.ShouldSkip(inorder, limitValue, inIndex)) return null;

        var currentValue = preorder[preIndex.index++]!;

        var left = this.BuildSubTree(preorder, inorder, currentValue, preIndex, inIndex);
        var right = this.BuildSubTree(preorder, inorder, limitValue, preIndex, inIndex);

        return new TreeNode(currentValue, left, right);
    }

    ShouldSkip(inorder: number[], limitValue: number | null, inIndex : byRefIndex) 
    {
        if (limitValue == null) return false;
        if (inorder[inIndex.index] == limitValue) 
            {
                inIndex.index += 1;
                return true;
            }
        return false;
    }

    
}