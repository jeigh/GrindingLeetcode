#pragma once

struct ListNode
{
    int val;
    ListNode* next;
    ListNode() : val(0), next(nullptr) {}
    explicit ListNode(const int x) : val(x), next(nullptr) {}
    ListNode(const int x, ListNode* next) : val(x), next(next) {}
};

class ReverseLinkedListII_92 {
    virtual ListNode* reverseBetween(ListNode* head, int left, int right) = 0;
};