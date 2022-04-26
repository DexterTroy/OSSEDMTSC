b = [0.0, 2.0, 0.0, 1.0, 0.0, 0.0];
a = [0.0, 0.0, 0.5, 2.0, 0.0, 1, 0.0];

c = [1,2,3,4];
d = [1,3,2,1,4];
testValue = dtw(a,b);
testValue2 = lcss(c,d);
disp(testValue2);