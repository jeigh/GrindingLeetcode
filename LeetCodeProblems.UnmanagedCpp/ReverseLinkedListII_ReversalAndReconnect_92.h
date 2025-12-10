#pragma once
#include "ListNode.h"

class ReverseLinkedListII_ReverseAndReconnect_92 : public ReverseLinkedListII_92 {
public:
    inline ListNode* reverseBetween(ListNode* head, int left, int right) 
    {
        auto dummy = ListNode(0, head);
        auto leftExclusiveBoundary = &dummy;

        // traverse to start of reversal segment
        for (int i = 1; i < left; i++)
        {
            leftExclusiveBoundary = leftExclusiveBoundary->next;
        }

        ListNode* prev = nullptr;
        
        auto firstNodeOfReversalSegment = leftExclusiveBoundary->next;
        auto current = firstNodeOfReversalSegment;

        // reverse incrementally
        for (int i = 0; i <= right - left; i++)
        {
            auto currentNext = current->next;

            current->next = prev;

            prev = current;
            current = currentNext;
        }

        // reconnect
        firstNodeOfReversalSegment->next = current;
        leftExclusiveBoundary->next = prev;

        return dummy.next;
    }
};