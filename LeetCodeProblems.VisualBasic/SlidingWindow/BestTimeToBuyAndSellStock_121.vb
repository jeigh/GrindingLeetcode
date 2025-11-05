Imports LeetCodeProblems.Interfaces

Namespace SlidingWindow
    Public Class BestTimeToBuyAndSellStock_121
        Implements IBestTimeToBuyAndSellStock_121

        Public Function MaxProfit(prices() As Integer) As Integer Implements IBestTimeToBuyAndSellStock_121.MaxProfit
            Dim left As Integer = 0
            Dim right As Integer = 1
            Dim retval As Integer = 0

            While right < prices.Length
                If prices(right) > prices(left) Then
                    retval = Math.Max(prices(right) - prices(left), retval)
                Else
                    left = right
                End If

                right = right + 1
            End While


            Return retval
        End Function
    End Class

End Namespace

