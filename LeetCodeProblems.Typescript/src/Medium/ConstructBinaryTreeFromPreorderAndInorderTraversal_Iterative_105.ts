import {IConstructBinaryTreeFromPreorderAndInorderTraversal_105} from "../Interfaces/Medium/IConstructBinaryTreeFromPreorderAndInorderTraversal_105";
import {TreeNode} from "../Shared";

type index = number;

export class ConstructBinaryTreeFromPreorderAndInorderTraversal_Iterative_105 implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105 
{
    buildTree(preorder: number[], inorder: number[]): TreeNode | null 
    {
        let inorderIndices = this.generateIndices(inorder);
        let stack : [parent:TreeNode|null, inorderLeft:index, inorderRight:index, isRight:boolean][] = [];
        stack.push([null, 0, inorder.length - 1, true]);
        let root:TreeNode|null = null;
        let preIndex = 0;

        while (stack.length > 0) 
        {

            let [parent, inorderLeft, inorderRight, isRight] = stack.pop()!;

            if (preIndex >= preorder.length) continue;
            if (inorderLeft > inorderRight) continue;

            let currentValue : number = preorder[preIndex++]!;
            let inorderIndex : index = inorderIndices.get(currentValue)!;

            let node = new TreeNode(currentValue);

            if (parent == null) root = node;
            else if (isRight) parent!.right = node;
            else parent!.left = node;

            if (inorderRight > inorderIndex)
                stack.push([node, inorderIndex + 1, inorderRight, true]);
            
            if (inorderIndex > inorderLeft)
                stack.push([node, inorderLeft, inorderIndex - 1, false]);            
        }

        return root;
    }

    generateIndices(inorder:number[]) : Map<number, index> 
    {
        let map = new Map<number, index>()
        for (let i = 0; i < inorder.length; i++) 
        {
            map.set(inorder[i]!, i);
        }
        return map;
    }

    
}