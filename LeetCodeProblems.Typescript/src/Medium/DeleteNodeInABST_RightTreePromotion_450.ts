import { IDeleteNodeInABST_450 } from "../Interfaces/Medium/IDeleteNodeInABST_450";
import { TreeNode } from "../Shared";


export class DeleteNodeInABST_RightTreePromotion_450 implements IDeleteNodeInABST_450 {
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

        if (_root.right == null) {
            let temp = _root.left;
            _root = null;
            return temp;
        }
        if (_root.left == null) {

            let temp = _root.right;
            _root = null;
            return temp;
        }

        let successor = _root.right;
        while (successor.left != null) successor = successor.left;

        successor.left = _root.left;
        let returnable = _root.right;
        _root = null; // in a non gc language, this is where we would free the memory

        return returnable;
    }
}
