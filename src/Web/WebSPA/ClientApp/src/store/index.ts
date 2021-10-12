import { configureStore } from "@reduxjs/toolkit";
import {loadUser, reducer as oidcReducer} from 'redux-oidc';
import { routerMiddleware } from 'react-router-redux'
import userManager from "utils/user-manager";
import { createBrowserHistory } from 'history'

export const rootReducer = {
  oidc: oidcReducer,
};


export const history = createBrowserHistory()
const middleware = routerMiddleware(history)

export const store = configureStore({
  reducer: rootReducer,
  middleware: [middleware]
});

loadUser(store, userManager);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;



