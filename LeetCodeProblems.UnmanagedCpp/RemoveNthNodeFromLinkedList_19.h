#pragma once

#include "ListNode.h"

class RemoveNthNodeFromLinkedList_19 {
public:
    inline ListNode* removeNthFromEnd(ListNode* head, int n) 
    {
        ListNode dummy = ListNode(0, head);
                
        ListNode* prev = &dummy;
        ListNode* eol = &dummy;

        if (!AdvanceBy(n + 1, eol)) return nullptr;   

        while (eol != nullptr) 
        {
            eol = eol->next;
            prev = prev->next;
        }

        if (!RemoveNextNodeFromList(prev)) return nullptr; 

        return dummy.next;
    }

private:
    inline bool AdvanceBy(int count, ListNode*& node)
    {
        while (count > 0)
        {
            if (node == nullptr) return false;
            node = node->next;
            count--;
        }
        return true;
    }

    inline bool RemoveNextNodeFromList(ListNode* prev) 
    {
        if (prev->next != nullptr) 
        {
            prev->next = prev->next->next;
            return true;
        }
        return false;
    }


};