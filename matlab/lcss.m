function [distance] = lcss(s1,s2)

n = length(s1);
m = length(s2);

d = zeros(n + 1, m + 1);

for i = n :-1: 1
    for j = m :-1: 1
        d(i,j) = d(i+1,j+1);
        if s1(i) == s2(j)
            d(i,j) = d(i,j) + 1;
        elseif d(i,j+1) > d(i,j)
            d(i,j) = d(i,j+ 1);
        elseif d(i + 1,j) > d(i,j)
            d(i,j) = d(i + 1,j);
        end
    end
end

distance = d(1,1);
