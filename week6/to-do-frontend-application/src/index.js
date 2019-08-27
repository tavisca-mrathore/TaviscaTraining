import React from 'react';
import ReactDOM from 'react-dom';
import Header from './HeaderComponent/Header';
import Footer from './FooterComponent/Footer';
import ContentWrapper from './ContentWrapperComponent/ContentWrapper';
import './index.css';
import * as serviceWorker from './serviceWorker';

let appLayout = (
    <div>
        <Header />
        <ContentWrapper />
        <Footer />
    </div>
);

ReactDOM.render(appLayout, document.getElementById('root'));

serviceWorker.unregister();
