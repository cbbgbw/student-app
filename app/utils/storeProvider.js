import React, { createContext, useContext } from "react";

export const StoreContext = createContext(null);

export const StoreProvider = ({ children, store }) => (
  <StoreContext.Provider value={store}>{children}</StoreContext.Provider>
);

export const useStore = (selector, eqFn) =>
  useContext(StoreContext)(selector, eqFn);

// TODO Add typescript typings
