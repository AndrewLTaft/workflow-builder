describe('workflows', () => {
  beforeEach(() => cy.visit('/workflows'));

  it('have option to add workflow', () => {
    cy.findByRole('link', { name: 'New Workflow' }).click();
    cy.findByRole('button', { name: 'Submit' }).should('be.disabled');
    cy.findByLabelText('Name').type('random workflow name');
    cy.findByRole('button', { name: 'Submit' }).should('be.enabled');

    cy.findByRole('button', { name: 'Add Step' }).click();
    cy.findByPlaceholderText('Step name').type('step1');

    cy.findByRole('button', { name: 'Submit' }).click();
    cy.findAllByRole('link', { name: 'random workflow name' }).should(
      'have.length.at.least',
      1
    );
  });
});
