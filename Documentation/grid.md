# Grid Documentation

This document serves to outline the grid system in HexArena.

## The Grid

HexArena consists of an NxM grid of hexagons, offset to be seamless, where n, m % 2 == 1

Each hex corresponds to a Tile object, which holds Coordinate, Vector and EntityOccupant data. 
