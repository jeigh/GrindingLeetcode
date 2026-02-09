import {IConstructBinaryTreeFromPreorderAndInorderTraversal_105} from "../Interfaces/Medium/IConstructBinaryTreeFromPreorderAndInorderTraversal_105";
import {TreeNode} from "../Shared";

type index = number;

interface byRefIndex {
    index: index
}

export class ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_105 implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105 
{
    buildTree(preorder: number[], inorder: number[]): TreeNode | null 
    {
        let preIndex : byRefIndex = {index:0};
        let inorderIndices = this.GenerateInorderIndices(inorder);
        return this.buildSubTree(preorder, inorderIndices, preIndex, 0, inorder.length - 1)
    }

    buildSubTree(preorder: number[], inorderIndices:Map<number, index>, preIndex: byRefIndex, inStart: index, inEnd: index):  TreeNode | null
    {
        if (preIndex.index >= preorder.length ) return null;
        if (inStart > inEnd) return null;

        let currentValue = preorder[preIndex.index++]!;
        let inorderIndex = inorderIndices.get(currentValue)!;        

        let left = this.buildSubTree(preorder, inorderIndices, preIndex, inStart, inorderIndex - 1);
        let right = this.buildSubTree(preorder, inorderIndices, preIndex, inorderIndex + 1, inEnd);

        return new TreeNode(currentValue, left, right);
    }
    
    GenerateInorderIndices(inorder:number[]) : Map<number, index>
    {
        let r = new Map<number, index>();
        for (let i = 0; i < inorder.length; i++) r.set(inorder[i]!, i);
        return r;
    }
}