import React, { FC } from 'react'
import { CyberpunkTheme } from '../../types/color'

export const navWidth = 100
export const Navigation: FC = () => {
  const navigationList = [
    {
      name: 'Pulpit',
      href: '/app',
    },
    {
      name: 'Przedmioty',
      href: '/subjects',
    },
  ]

  return (
    <aside className="app-navigation">
      <ul>
        {navigationList.map((el) => (
          <li key={el.name}>Icon</li>
        ))}
        <button className="cyberpunk">Hype the beast</button>
      </ul>
      <style jsx>
        {`
          .app-navigation {
            position: absolute;
            height: 100%;
            left: 0;
            top: 0;

            border: 1px solid red;
            width: ${navWidth}px;
            box-sizing: border-box;
          }

          .cyberpunk {
            background: ${CyberpunkTheme.Black};
            color: ${CyberpunkTheme.Pantone};
          }
        `}
      </style>
    </aside>
  )
}
