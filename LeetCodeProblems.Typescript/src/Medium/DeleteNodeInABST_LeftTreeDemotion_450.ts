import {IDeleteNodeInABST_450} from "../Interfaces/Medium/IDeleteNodeInABST_450";
import {TreeNode} from "../Shared";

export class DeleteNodeInABST_LeftTreeDemotion_450 implements IDeleteNodeInABST_450 {
    deleteNode(_root: TreeNode | null, _key: number): TreeNode | null {
        if (_root == null) return null;

        if (_key > _root.val) {
            _root.right = this.deleteNode(_root.right, _key);
            return _root;
        }

        if (_key < _root.val) {
            _root.left = this.deleteNode(_root.left, _key);
            return _root;
        }

        if (_root.left == null) return _root.right;
        if (_root.right == null) return _root.left;

        var leftTree = _root.left;
        var rightTree = _root.right;

        var attachPoint = rightTree;
        while (attachPoint.left != null) attachPoint = attachPoint.left;

        attachPoint.left = leftTree;

        return rightTree;
    }
}