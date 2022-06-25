Author: Maria Hinge Pedersen 201706201
Exam project 01:
The matrix to diagonalize is given in the form A = D + e(p)u^T + ue(p)^T,
where D is a diagonal matrix with diagonal elements {d_k, k = 1, ..., n},
u is a given column-vector, and the vector e(p) with components e(p)_i = delta_ip is a unit vector in the direction p where 1 <= p <= n.
Given the diagonal elements of the matrix D, the vector u, and the interger p, calculate the eigenvalues of the matrix A using O(n^2) operations (see section "Eigenvalues of updated matrix" in the book).

This folder contains my solution to this exam project, where the matrix A is determined using formula (26) in the book, that is A = D + e(p)u^T + ue(p)^T.
Then by using the Newton-Raphson method for root finding, which needs O(n^2) operations, we find the updated eigenvalues with the secular equation (30).


