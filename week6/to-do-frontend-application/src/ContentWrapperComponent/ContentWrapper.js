import React from 'react';
import SideNavigation from './SideNavigationComponent/SideNavigation';
import ToDoListingWrapper from './ToDoListingComponent/ToDoListingComponent';
import './style.css';

class ContentWrapper extends React.Component {
    render() {
        return (
            <div id="content-container" >
                <SideNavigation />
                <ToDoListingWrapper />
            </div>
        );
    }
}

export default ContentWrapper;
