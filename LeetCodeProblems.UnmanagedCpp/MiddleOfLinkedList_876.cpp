#pragma once

#include "MiddleOfLinkedList_876.h"

ListNode* MiddleOfLinkedListCpp_876::middleNode(ListNode* head) 
{
    if (head == nullptr) return nullptr;
    if (head->next == nullptr) return head;

    ListNode* slow = head;
    ListNode* fast = head;

    while (fast != nullptr && fast->next != nullptr) 
    {
        fast = fast->next->next;
        slow = slow->next;
    }

    return slow;
}