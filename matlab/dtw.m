function [distance] = dtw(s1,s2)

n = length(s1) + 1;
m = length(s2) + 1;

d = zeros(n, m, 'double');

for i = 1 : n
    d(i,1) = inf;
end


for i = 1 : m
    d(1,i) = inf;
end

d(1,1) = 0;


for i = 2 : n
    for j = 2 : m
        d(i,j) = abs(s1(i-1) - s2(j-1)) ... 
            + min(d(i-1,j), min(d(i,j-1),d(i-1,j-1)));
    end
end

distance = d(i,j);
