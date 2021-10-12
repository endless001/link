import { lazy } from "react";
import BasicLayout from "layouts/basic-layout";


const NotFound = lazy(() => import("modules/not-found/not-found"));
const Callback = lazy(() => import("modules/callback/callback"));
const Message = lazy(() => import("modules/message/message"));
const Contact = lazy(() => import("modules/contact/contact"));
const Group = lazy(() => import("modules/group/group"));
const Settings = lazy(() => import("modules/settings/settings"));

export const routes = [
  {
    path: '/',
    element:   <BasicLayout/>,
    children: [
      { path: '/', element:<Message/> },
      { path: '/contact', element:<Contact/> },
      { path: '/group', element:<Group/> },
      { path: '/settings', element:<Settings/>  }
    ]
  },
  { path: 'callback',element: <Callback/> },
  { path: 'home', redirectTo: '/' },
  { path: '*', element:<NotFound/> }
];



