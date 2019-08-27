import React from 'react';
import './style.css';

class SearchBar extends React.Component {
    render() {
        return (
            <div id="search-section" >
                <input type="text" />
                <button>ADD</button>
            </div>
        );
    }
}

export default SearchBar;
