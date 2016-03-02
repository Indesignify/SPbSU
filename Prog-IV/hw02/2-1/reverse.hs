-- reversing the list
supReverse :: [a] -> [a] -> [a]
supReverse l [] = l
supReverse y (x : xs) = supReverse (x : y) xs

reverse' :: [a] -> [a]
reverse' = supReverse []