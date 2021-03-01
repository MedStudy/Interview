import { ArrayFirstOrDefaultPipe } from './array-first-or-default.pipe';

describe('ArrayFirstOrDefaultPipe', () => {
  it('create an instance', () => {
    const pipe = new ArrayFirstOrDefaultPipe();
    expect(pipe).toBeTruthy();
  });
});
