function removeDuplicates(nums: number[]): number[] {
	let prev: number | null = null;
	for (let i = 0; i < nums.length; i++) {
		if (i === 0) {
			prev = nums[i]
			continue;
		}
		if (nums[i] === prev) {
			nums[i] = -1
		}
		prev = nums[i]
	}
	for (let i = 0; i < nums.length; i++) {
		if (nums[i] === -1) {
			nums.push(...nums.splice(i, 1));
		}
	}
	return nums;
}


console.log(removeDuplicates([0, 0, 1, 1, 1, 2, 2, 3, 3, 4]))