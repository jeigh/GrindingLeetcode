#pragma once

#include "ReverseListCpp_206.h"

ListNode* ReverseListCpp_206::reverseList(ListNode* head)
{
    if (head == nullptr || head->next == nullptr) return head;

    ListNode* first = nullptr;
    ListNode* second = head;

    while (second != nullptr)
    {
        ListNode* secondNext = second->next;
        second->next = first;

        first = second;
        second = secondNext;
    }

    return first;
}