#pragma once
#include "ListNode.h"


class ReverseLinkedListII_MoveToFront_92 : public ReverseLinkedListII_92 {
public:
    inline ListNode* reverseBetween(ListNode* head, int left, int right)
    {
        auto dummy = ListNode(0, head);
        auto leftExclusiveBoundary = &dummy;

        for (int i = 1; i < left; i++)
        {
            leftExclusiveBoundary = leftExclusiveBoundary->next;
        }

        ListNode* anchor = leftExclusiveBoundary->next;

        for (int i = left; i < right; i++) 
        {
            auto toInsert = anchor->next;
            // move anchor forward
            anchor->next = anchor->next->next;

            // insert toInsert between leftExclusiveBoundary and leftExclusiveBoundary->next
            toInsert->next = leftExclusiveBoundary->next;
            leftExclusiveBoundary->next = toInsert;
        }

        return dummy.next;
    }
};