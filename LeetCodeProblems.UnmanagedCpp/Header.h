#pragma once

#include "ListNode.h"

class RemoveNthNodeFromLinkedList_19 {
public:
    inline ListNode* removeNthFromEnd(ListNode* head, int n) 
    {
        ListNode dummy;
        dummy.next = head;
        
        ListNode* prev = &dummy;
        ListNode* eol = &dummy;

        AdvanceBy(n, &dummy);
        


        RemoveNextNodeFromList(prev);
    }

private:
    inline ListNode* AdvanceBy(int count, ListNode* head) 
    {

    }

    inline void RemoveNextNodeFromList(ListNode* prev) 
    {

    }


};