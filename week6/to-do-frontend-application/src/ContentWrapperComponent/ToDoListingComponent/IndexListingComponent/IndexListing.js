import React from 'react';
import './style.css';

class IndexListing extends React.Component {
  constructor(props) {
    super(props);
    this.state = this.props;
  }

  MakeRowStructure() {
    let tableStructure = [];

    for (let index = 0; index < this.state.DataToBeRendered.length; index++) {
      tableStructure.push(
        <tr className="table-row-{index}">
          <td>{this.state.DataToBeRendered[index].title}</td>
          <td>
            <button>Edit</button>
          </td>
          <td>
            <button>Delete</button>
          </td>
        </tr>
      );
    }
    return (
      <table id="index-listing-contaier">
        <tbody>
          {tableStructure}
        </tbody>
      </table>
    );
  }
  render() {
    return this.MakeRowStructure();
  }
}

export default IndexListing;
