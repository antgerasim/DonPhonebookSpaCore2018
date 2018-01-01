import { PhonebookSpaTemplatePage } from './app.po';

describe('PhonebookSpa App', function() {
  let page: PhonebookSpaTemplatePage;

  beforeEach(() => {
    page = new PhonebookSpaTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
