import {IDeleteNodeInABST_450} from "../Interfaces/Medium/IDeleteNodeInABST_450";
import {TreeNode} from "../Shared";

export class DeleteNodeInABST_DirectSuccessorPromotion_450 implements IDeleteNodeInABST_450 {
    deleteNode(_root: TreeNode | null, _key: number): TreeNode | null {
        if (_root == null) return null;

        if (_key > _root.val) {
            _root.right = this.deleteNode(_root.right, _key);
            return _root;
        }

        if (_key < _root.val) {
            _root.left = this.deleteNode(_root.left, _key)
            return _root;
        }

        if (_root.right == null) return _root.left;
        if (_root.left == null) return _root.right;

        let successor = this.detachSuccessor(_root);

        successor.left = _root.left;
        successor.right = _root.right;

        _root = null;  // not necessary, but if we weren't in a garbage collected language, we would want to free this memory here.

        return successor;        
    }

    detachSuccessor(_node: TreeNode): TreeNode {
        let parent = _node;
        let successor  = _node.right!;
        let lastMovedRight = true;

        while (successor.left != null) {
            parent = successor;
            successor = successor.left;
            lastMovedRight = false;
        }        

        if (lastMovedRight)
            parent.right = successor.right;
        else
            parent.left = successor.right;

        return successor;
    }
}

