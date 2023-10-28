import { NumberToWOrdsPipe } from './number-to-words.pipe';

describe('NumberToWOrdsPipe', () => {
  it('create an instance', () => {
    const pipe = new NumberToWOrdsPipe();
    expect(pipe).toBeTruthy();
  });
});
