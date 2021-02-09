import React from 'react'

export const useStateWithLocalStorage = (localStorageKey: string) => {
  const [value, setValue] = React.useState<any>('')

  React.useEffect(() => {
    if (typeof window !== 'undefined') {
      setValue(localStorage.getItem(localStorageKey))
    }
  })

  return [value, setValue]
}
