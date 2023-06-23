# Symmetric rank-1 update of a size-n symmetric eigenvalue problem

My last two numbers of the student number are 89 and the project I have is therefore (89 mod 26) 11.


Self-Rating: 9 

### Description, Thoughts 

In this project, I have made the diagonal matrix D size n,n with random values between 1 and 5. The column-vector u also has random values between 1 and 5 such m equals n in the book http://212.27.24.106:8080/prog/book/eigen.pdf. I separated the diagonal values for d with two times the max value of u^Tu such that I ensured that the eigenvalues are in compliance with equation 25 (I also tested if this is really true) where sigma is 1 as described in the exam question 11. 

The Next task is to calculate the equation 23 and find all n roots of the equation which equals all n (updated) eigenvalues. I used the Newton-Raphson Method to find these roots. My initial guess for the root is d[i,i] + u^Tu/2 since it should be fairly close to an eigenvalue. Then I test if f(guess) is close to zero with the uncertainty +- 1e-3 if its true I stop the iterations and if not the next guess will be calculated with the Newton-Raphson Method as guess_(n+1)=guess_n - f(guess_n)/f'(guess_n). This will then be processed until one eigenvalue has been found. 

In my Out.txt I first test that I can find eigenvalues for a simple 5x5 D matrix with a 5 long u column-vector with extensive testing. Next I do it for a random sized D matrix (n can be anything from 400 to 500) and check if the same testing still apllies. It did and then I made the plot on operations_pr_n.svg. The yaxis is summed oprations divided by n^2, x-axis is n and if since this is a flat equation then I am finding the (updated) eigenvalues of A only using O(n^2) operations.

Hereby I think that my problem solving complexity align good with the B-level, which explains the self-rating of 9. 
