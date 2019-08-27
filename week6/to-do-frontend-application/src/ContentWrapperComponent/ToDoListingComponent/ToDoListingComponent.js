import React from 'react';
import './style.css';
import AutopopulateData from './Data';
import IndexListing from './IndexListingComponent/IndexListing';
import SearchBar from './SearchBarComponent/SearchBar';

class ToDoListingWrapper extends React.Component {
    render() {
        return (
            <div id="sidenav-content-container">
                <SearchBar />
                <IndexListing DataToBeRendered={AutopopulateData} />
            </div>
        );
    }
}

export default ToDoListingWrapper;