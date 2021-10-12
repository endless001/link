import React from "react";
import userManager from "utils/user-manager";
import {connect} from 'react-redux';
import {CallbackComponent} from "redux-oidc";
import {AppDispatch} from "store";
import {useErrorHandler} from "react-error-boundary";

interface CallbackProps {
  dispatch: AppDispatch;
}

const Callback = (props: CallbackProps) => {
    const handleError = useErrorHandler();

    return (<CallbackComponent
        userManager={userManager}
        successCallback={() => {
            window.location.href = "/";
        }}
        errorCallback={error => {
           handleError(error);
        }}
    >
        <div>Redirecting...</div>
    </CallbackComponent>);
};
export default connect()(Callback);
