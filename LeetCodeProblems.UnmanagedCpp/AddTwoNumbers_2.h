#pragma once

#include "ListNode.h"

class AddTwoNumbers_2 {
public:
    inline ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) 
    {
        auto firstNode = l1;
        auto secondNode = l2;

        ListNode dummy = ListNode(0);
        ListNode* prevNode = &dummy;
        int carry = 0;

        while (firstNode != nullptr || secondNode != nullptr || carry > 0) 
        {
            auto firstNodeVal = 0;
            auto secondNodeVal = 0;

            if (firstNode != nullptr) firstNodeVal = firstNode->val;
            if (secondNode != nullptr) secondNodeVal = secondNode->val;

            auto sum = carry + firstNodeVal + secondNodeVal;
            
            carry = sum / 10;
            sum = sum % 10;
            
            // in an real app, this would be a memory leak unless the caller knows to clean up every node in the resultant linked list.
            prevNode->next = new ListNode(sum);

            prevNode = prevNode->next;
            if (firstNode != nullptr) firstNode = firstNode->next;
            if (secondNode != nullptr) secondNode = secondNode->next;
        }

        return dummy.next;        
    }
};