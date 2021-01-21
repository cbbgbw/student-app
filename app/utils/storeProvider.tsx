import React, { createContext, FC, useContext } from 'react'
import { Hydrate, StoreType } from './storeUtils'
import { EqualityChecker, StateSelector } from 'zustand/vanilla'
import shallow from 'zustand/shallow'
import { UseStore } from 'zustand'
import { StateCombined } from '../store/modules/modules'

export const ZustandContext = createContext<Hydrate>(
  // eslint-disable-next-line @typescript-eslint/consistent-type-assertions
  {} as Hydrate,
)

interface ProviderProps {
  store: Hydrate
}

export const StoreProvider: FC<ProviderProps> = ({ children, store }) => (
  <ZustandContext.Provider value={store}>{children}</ZustandContext.Provider>
)

export function useStore<U>(selector: StateSelector<StateCombined, U>) {
  const store = useContext(ZustandContext)
  return store(selector)
}
