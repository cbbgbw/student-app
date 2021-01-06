import React, { createContext, useContext } from 'react'

export const StoreContext = createContext(null)

export const StoreProvider = ({ children, store }) => (
  <StoreContext.Provider value={store}>
    {children}
  </StoreContext.Provider>
)

export const useStore = (selector, eqFn) => {
  const store = useContext(StoreContext)
  return store(selector, eqFn)
}

// TODO Add typescript typings
