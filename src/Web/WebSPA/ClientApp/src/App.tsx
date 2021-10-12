import React, {useState,Suspense} from 'react';
import 'remixicon/fonts/remixicon.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'App.css'
import {useRoutes} from "react-router-dom";
import {routes} from 'components/routes/routes';
import {ErrorBoundary} from "react-error-boundary";
import {ErrorFallback, FullPageLoading} from "components/library";


function App() {
    const routing = useRoutes(routes);
    return (
        <div>
            <ErrorBoundary FallbackComponent={ErrorFallback}>
                <Suspense fallback={<FullPageLoading/>}>
                {routing}
               </Suspense>
            </ErrorBoundary>
        </div>
    );
}

export default App;
